using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Exceptions;
using NOM.Domain._Base.Extentions;
using NOM.Domain._Base.Handlers;
using NOM.Domain.Application.Properties.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.Domain.Application.Categories.Commands;
/// <summary>
/// haitc 02/06/2022
/// </summary>

public class CategoriesHandler : BaseHandler,
                                 ICommandHandler<CreateCategoriesCmd, CreateCategoriesResult>,
                                 ICommandHandler<UpdateCategoriesCmd, UpdateCategoriesResult>,
                                 ICommandHandler<DeleteCategoriesCmd, DeleteCategoriesResult>
{
    public CategoriesHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    /// <summary>
    /// Create Category
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateCategoriesResult> Handle(CreateCategoriesCmd request, CancellationToken cancellationToken)
    {
        bool existingEntity = await _context.Categories
                                    .Where(x => x.CategoryName == request.CategoryName
                                                                  && x.Status > 0)
                                    .AnyAsync();
        if (existingEntity)
        {
            throw new ConflictException($"Tên danh mục '{request.CategoryName}' đã tồn tại");
        }
        var categoriesEntity = _mapper.Map<Category>(request);
        categoriesEntity.CategoryId = Guid.NewGuid().ToString();
        categoriesEntity.CreatedDate = DateTime.Now;
        categoriesEntity.CreatedBy = "Haitc";
        await _context.Categories.AddAsync(categoriesEntity);

        #region Lưu thuộc tính

        if (request.CreatePropertiesCmds.Count() > 0)
        {
            #region Kiểm tra duplicate

            var duplicatedPropertyCode = request.CreatePropertiesCmds
                                      .CheckDuplicate(x => x.PropertyCode);
            if (duplicatedPropertyCode.Count() > 0)
            {
                throw new ConflictException($"Mã thuộc tính '{String.Join(", ", duplicatedPropertyCode)}' trùng lặp");
            }
            var duplicatedPropertyName = request.CreatePropertiesCmds
                                        .CheckDuplicate(x => x.PropertyName);
            if (duplicatedPropertyName.Count() > 0)
            {
                throw new ConflictException($"Tên thuộc tính '{String.Join(", ", duplicatedPropertyName)}' trùng lặp");
            }
            var duplicatedAliasName = request.CreatePropertiesCmds
                                      .CheckDuplicate(x => x.AliasName);
            if (duplicatedAliasName.Count() > 0)
            {
                throw new ConflictException($"Tên hiển thị thuộc tính '{String.Join(", ", duplicatedAliasName)}' trùng lặp");
            }

            #endregion Kiểm tra duplicate

            // Thêm properties
            var lstPropertiesEntity = new List<Property>();
            foreach (var propertyCmdDto in request.CreatePropertiesCmds)
            {
                var propertyEntity = _mapper.Map<Property>(propertyCmdDto);
                propertyEntity.PropertyId = Guid.NewGuid().ToString();
                propertyEntity.CreatedDate = DateTime.Now;
                propertyEntity.CreatedBy = "haitc";
                propertyEntity.CategoryId = categoriesEntity.CategoryId;
                propertyEntity.ParentCategoryId = categoriesEntity.ParentCategoryId;
                lstPropertiesEntity.Add(propertyEntity);
            }
            await _context.Properties.AddRangeAsync(lstPropertiesEntity);
        }

        #endregion Lưu thuộc tính

        var relSave = await _context.SaveChangesAsync(cancellationToken);
        if (relSave < 0)
        {
            throw new FailureSaveChangesException("Tạo danh mục thất bại");
        }
        return new CreateCategoriesResult(categoriesEntity.CategoryId, categoriesEntity.CategoryName);
    }

    /// <summary>
    /// Update category
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    /// <exception cref="ConflictException"></exception>
    /// <exception cref="FailureSaveChangesException"></exception>
    public async Task<UpdateCategoriesResult> Handle(UpdateCategoriesCmd request, CancellationToken cancellationToken)
    {
        var categoriesEntity = await _context.Categories
                                     .Where(x => x.CategoryId == request.CategoryId)
                                     .FirstOrDefaultAsync();
        if (categoriesEntity is null)
        {
            throw new NotFoundException($"Danh mục id: '{request.CategoryId}' không tồn tại ");
        }
        if (categoriesEntity.CategoryName != request.CategoryName)
        {
            bool existingEntity = await _context.Categories
                                        .Where(x => x.CategoryName == request.CategoryName
                                                                      && x.Status > 0)
                                        .AnyAsync();
            if (existingEntity)
                throw new ConflictException($"Tên kiểu danh mục '{request.CategoryName}' đã tồn tại");
        }
        _mapper.Map<CategoriesCmdDto, Category>(request, categoriesEntity);
        categoriesEntity.ModifiedBy = "Haitc";
        categoriesEntity.ModifiedDate = DateTime.Now;
        _context.Categories.Update(categoriesEntity);

        #region Lưu thuộc tính

        // Nếu có properties thì xử lý nếu không thì xóa hết propertis
        // Danh sách thuộc tính đang lưu trong Db
        var curentPropertiesEntity = await _context.Properties
                           .Where(p => p.CategoryId == categoriesEntity.CategoryId)
                           .ToListAsync();
        if (request.UpdatePropertiesCmds.Count() > 0)
        {
            #region Kiểm tra duplicate

            var duplicatedPropertyCode = request.UpdatePropertiesCmds
                                     .CheckDuplicate(x => x.PropertyCode);
            if (duplicatedPropertyCode.Count() > 0)
            {
                throw new ConflictException($"Mã thuộc tính '{String.Join(", ", duplicatedPropertyCode)}' trùng lặp");
            }
            var duplicatedPropertyName = request.UpdatePropertiesCmds
                                        .CheckDuplicate(x => x.PropertyName);
            if (duplicatedPropertyName.Count() > 0)
            {
                throw new ConflictException($"Tên thuộc tính '{String.Join(", ", duplicatedPropertyName)}' trùng lặp");
            }
            var duplicatedAliasName = request.UpdatePropertiesCmds
                                      .CheckDuplicate(x => x.AliasName);
            if (duplicatedAliasName.Count() > 0)
            {
                throw new ConflictException($"Tên hiển thị thuộc tính '{String.Join(", ", duplicatedAliasName)}' trùng lặp");
            }

            #endregion Kiểm tra duplicate

            // Thêm properties
            var lstPropertiesEntityAdd = new List<Property>();
            var PropertiesCmdDtosAdd = request.UpdatePropertiesCmds
                                       .Where(x => string.IsNullOrEmpty(x.PropertyId)).ToList();
            if (PropertiesCmdDtosAdd.Count() > 0)
            {
                foreach (var propertyCmdDto in PropertiesCmdDtosAdd)
                {
                    var propertyEntity = _mapper.Map<Property>(propertyCmdDto);
                    propertyEntity.PropertyId = Guid.NewGuid().ToString();
                    propertyEntity.CreatedDate = DateTime.Now;
                    propertyEntity.CreatedBy = "haitc";
                    propertyEntity.CategoryId = categoriesEntity.CategoryId;
                    propertyEntity.ParentCategoryId = categoriesEntity.ParentCategoryId;
                    lstPropertiesEntityAdd.Add(propertyEntity);
                }
                await _context.Properties.AddRangeAsync(lstPropertiesEntityAdd);
            }

            // Sửa properties
            var UpdatePropertiesCmdsHasId = request.UpdatePropertiesCmds
                                            .Where(dto => !string.IsNullOrEmpty(dto.PropertyId)).ToList();
            var lstIdPropertyChanged = UpdatePropertiesCmdsHasId
                                       .Select(dto => dto.PropertyId)
                                       .ToList();
            var lstPropertiesEntityUpdate = new List<Property>();
            var lstPropertiesEntityOld = curentPropertiesEntity
                                          .Where(xntity => lstIdPropertyChanged.Contains(xntity.PropertyId));
            if (lstPropertiesEntityOld.Count() > 0)
            {
                foreach (var propertyEntity in lstPropertiesEntityOld)
                {
                    var dto = UpdatePropertiesCmdsHasId
                              .FirstOrDefault(d => d.PropertyId == propertyEntity.PropertyId);
                    if (dto is null)
                    {
                        throw new NotFoundException($"Thuộc tính id: '{dto.PropertyId}' không tồn tại ");
                    }
                    _mapper.Map<UpdatePropertiesCmd, Property>(dto, propertyEntity);
                    propertyEntity.ModifiedBy = "haitc";
                    propertyEntity.ModifiedDate = DateTime.Now;
                    propertyEntity.CategoryId = categoriesEntity.CategoryId;
                    propertyEntity.ParentCategoryId = categoriesEntity.ParentCategoryId;
                    lstPropertiesEntityUpdate.Add(propertyEntity);
                }
                _context.Properties.UpdateRange(lstPropertiesEntityUpdate);
            }
            // Xoas properties
            var lstPropertiesEntityDelete = curentPropertiesEntity
                                           .Where(xntity => !lstIdPropertyChanged.Contains(xntity.PropertyId));
            if (lstPropertiesEntityDelete.Count() > 0)
            {
                _context.Properties.RemoveRange(lstPropertiesEntityDelete);
            }
        }
        else
        {
            // nếu trong request không có properties thì xóa hết properties
            _context.Properties.RemoveRange(curentPropertiesEntity);
        }

        #endregion Lưu thuộc tính

        var relSave = await _context.SaveChangesAsync(cancellationToken);
        if (relSave < 0)
        {
            throw new FailureSaveChangesException($"Sửa danh mục id: '{request.CategoryId} thất bại");
        }
        return new UpdateCategoriesResult(categoriesEntity.CategoryId, categoriesEntity.CategoryName);
    }

    /// <summary>
    /// Deletwe Category
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteCategoriesResult> Handle(DeleteCategoriesCmd request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
                           .Where(x => x.CategoryId == request.CategoryId)
                           .FirstOrDefaultAsync();
        if (entity is null)
        {
            throw new NotFoundException($"Danh mục id: '{request.CategoryId}' không tồn tại ");
        }
        _context.Categories.Remove(entity);

        // Xóa hết properties của category
        var propertiesEntity = await _context.Properties
                                    .Where(p => p.CategoryId == request.CategoryId)
                                    .ToListAsync();
        _context.Properties.RemoveRange(propertiesEntity);

        var relSave = await _context.SaveChangesAsync(cancellationToken);
        if (relSave < 0)
        {
            throw new FailureSaveChangesException($"Xóa danh mục id: '{request.CategoryId} thất bại");
        }
        return new DeleteCategoriesResult(entity.CategoryId, entity.CategoryName);
    }
}