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

namespace NOM.Domain.Application.OriginalProperties.Commands;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public class OriginalPropertiesHandler : BaseHandler,
                                         ICommandHandler<CreateOriginalPropertiesCmd, CreateOriginalPropertiesResult>,
                                         ICommandHandler<UpdateOriginalPropertiesCmd, UpdateOriginalPropertiesResult>,
                                         ICommandHandler<DeleteOriginalPropertiesCmd, DeleteOriginalPropertiesResult>
{
    public OriginalPropertiesHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    /// <summary>
    /// Create OriginalProperty
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateOriginalPropertiesResult> Handle(CreateOriginalPropertiesCmd request, CancellationToken cancellationToken)
    {
        bool existingEntity = await _context.OriginalProperties.Where(x => x.PropertyName == request.PropertyName && x.Status > 0).AnyAsync();
        if (existingEntity)
        {
            throw new ConflictException($"Tên thuộc tính '{request.PropertyName}' đã tồn tại");
        }
        var entity = _mapper.Map<OriginalProperty>(request);
        entity.PropertyId = Guid.NewGuid().ToString();
        entity.CreatedDate = DateTime.Now;
        entity.CreatedBy = "Haitc";
        await _context.OriginalProperties.AddAsync(entity);

        var relSave = await _context.SaveChangesAsync(cancellationToken);
        if (relSave < 0)
        {
            throw new FailureSaveChangesException("Tạo thuộc tính thất bại");
        }
        return new CreateOriginalPropertiesResult(entity.PropertyId, entity.PropertyCode, entity.PropertyName);
    }

    /// <summary>
    /// Update OriginalProperty
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    /// <exception cref="ConflictException"></exception>
    /// <exception cref="FailureSaveChangesException"></exception>
    public async Task<UpdateOriginalPropertiesResult> Handle(UpdateOriginalPropertiesCmd request, CancellationToken cancellationToken)
    {
        var entities = await _context.OriginalProperties.ToListAsync();
        var entity = entities
                     .Where(x => x.PropertyId == request.PropertyId)
                      .FirstOrDefault();
        if (entity is null)
        {
            throw new NotFoundException($"Thuộc tính id: '{request.PropertyId}' không tồn tại ");
        }
        if (entity.PropertyName != request.PropertyName)
        {
            bool existingEntity = entities
                                  .Where(x => x.PropertyName == request.PropertyName
                                              && x.Status > 0)
                                  .Any();
            if (existingEntity)
                throw new ConflictException($"Tên thuộc tính '{request.PropertyName}' đã tồn tại");
        }
        _mapper.Map<OriginalPropertiesCmdDto, OriginalProperty>(request, entity);
        entity.ModifiedBy = "Haitc";
        entity.ModifiedDate = DateTime.Now;
        _context.OriginalProperties.Update(entity);

        var relSave = await _context.SaveChangesAsync(cancellationToken);
        if (relSave < 0)
        {
            throw new FailureSaveChangesException($"Sửa thuộc tính id: '{request.PropertyId}' thất bại");
        }
        return new UpdateOriginalPropertiesResult(entity.PropertyId, entity.PropertyCode, request.PropertyName);
    }

    /// <summary>
    /// Deletwe OriginalProperty
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteOriginalPropertiesResult> Handle(DeleteOriginalPropertiesCmd request, CancellationToken cancellationToken)
    {
        var entity = await _context.OriginalProperties
                            .Where(x => x.PropertyId == request.PropertyId)
                            .FirstOrDefaultAsync();
        if (entity is null)
        {
            throw new NotFoundException($"Thuộc tính id: '{request.PropertyId}' không tồn tại ");
        }
        _context.OriginalProperties.Remove(entity);

        var relSave = await _context.SaveChangesAsync(cancellationToken);
        if (relSave < 0)
        {
            throw new FailureSaveChangesException($"Xóa thuộc tính id: '{request.PropertyId}' thất bại");
        }
        return new DeleteOriginalPropertiesResult(entity.PropertyId, entity.PropertyCode, entity.PropertyName);
    }
}