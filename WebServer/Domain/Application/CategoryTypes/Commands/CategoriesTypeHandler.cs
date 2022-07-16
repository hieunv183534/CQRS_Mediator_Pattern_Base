using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Exceptions;
using NOM.Domain._Base.Handlers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.Domain.Application.CategoryTypes.Commands;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public class CategoryTypeHandler : BaseHandler,
                                   ICommandHandler<CreateCategoriesTypeCmd, CreateCategoriesTypeResult>,
                                   ICommandHandler<UpdateCategoriesTypeCmd, UpdateCategoriesTypeResult>,
                                   ICommandHandler<DeleteCategoriesTypeCmd, DeleteCategoriesTypeResult>
{
    public CategoryTypeHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    /// <summary>
    /// Create CategoriesTypes
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateCategoriesTypeResult> Handle(CreateCategoriesTypeCmd request, CancellationToken cancellationToken)
    {
        bool existingEntity = await _context.CategoriesTypes
                                    .Where(x => x.CategoryTypeName == request.CategoryTypeName
                                                                      && x.Status > 0)
                                    .AnyAsync();
        if (existingEntity)
        {
            throw new ConflictException($"Tên kiểu danh mục '{request.CategoryTypeName}' đã tồn tại");
        }
        var entity = _mapper.Map<CategoriesType>(request);
        entity.CategoryTypeId = Guid.NewGuid().ToString();
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = "Haitc";
        await _context.CategoriesTypes.AddAsync(entity);

        var relSave = await _context.SaveChangesAsync(cancellationToken);
        if (relSave < 0)
        {
            throw new FailureSaveChangesException("Tạo kiểu danh mục thất bại");
        }
        return new CreateCategoriesTypeResult(entity.CategoryTypeId, entity.CategoryTypeName);
    }

    /// <summary>
    /// Update CategoriesTypes
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<UpdateCategoriesTypeResult> Handle(UpdateCategoriesTypeCmd request, CancellationToken cancellationToken)
    {
        var entities = await _context.CategoriesTypes.ToListAsync();
        var entity = entities
                    .Where(x => x.CategoryTypeId == request.CategoryTypeId)
                    .FirstOrDefault();
        if (entity is null)
        {
            throw new NotFoundException($"Kiểu danh mục id: '{request.CategoryTypeId}' không tồn tại ");
        }
        if (entity.CategoryTypeName != request.CategoryTypeName)
        {
            bool existingEntity = entities
                                 .Where(x => x.CategoryTypeName == request.CategoryTypeName
                                             && x.Status > 0)
                                 .Any();
            if (existingEntity)
                throw new ConflictException($"Tên kiểu danh mục '{request.CategoryTypeName}' đã tồn tại");
        }
        _mapper.Map<CategoriesTypeCmdDto, CategoriesType>(request, entity);
        entity.ModifiedBy = "Haitc";
        entity.Modifieddate = DateTime.Now;
        _context.CategoriesTypes.Update(entity);

        var relSave = await _context.SaveChangesAsync(cancellationToken);
        if (relSave < 0)
        {
            throw new FailureSaveChangesException($"Sửa kiểu danh mục id: '{request.CategoryTypeId}' thất bại");
        }
        return new UpdateCategoriesTypeResult(entity.CategoryTypeId, request.CategoryTypeName);
    }

    /// <summary>
    /// Deletwe CategoriesTypes
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteCategoriesTypeResult> Handle(DeleteCategoriesTypeCmd request, CancellationToken cancellationToken)
    {
        var entity = await _context.CategoriesTypes
                           .Where(x => x.CategoryTypeId == request.CategoryTypeId)
                           .FirstOrDefaultAsync();
        if (entity is null)
        {
            throw new NotFoundException($"Kiểu danh mục id: '{request.CategoryTypeId}' không tồn tại ");
        }
        _context.CategoriesTypes.Remove(entity);

        var relSave = await _context.SaveChangesAsync(cancellationToken);
        if (relSave < 0)
        {
            throw new FailureSaveChangesException($"Xóa kiểu danh mục id: '{request.CategoryTypeId}' thất bại");
        }
        return new DeleteCategoriesTypeResult(entity.CategoryTypeId, entity.CategoryTypeName);
    }
}