using AutoMapper;
using AutoMapper.QueryableExtensions;
using NOM.Common.Enums;
using NOM.DomainGlobal._Base.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class FindOneQuery : BaseWhereModel, IRequest<FindOneQueryResult>
    {
        
    }

}

