using AutoMapper;
using NOM.Common.Ultilities;
using NOM.Dao.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Commands
{
    public class ChangeParentCommandHandler : IRequestHandler<ChangeParentCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ChangeParentCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<long> Handle(ChangeParentCommand request, CancellationToken cancellationToken)
        {
            var dataOld = await _context.ReportManager.FindAsync(request.Id);
            var dataNew = dataOld;

            string parentTagOld = dataOld.ParentTag;

            //string parentTagCurrent = dataOld.ParentTag;

            //dataNew.ParentId = request.IdParent;

            if (request.IdParent == null || request.IdParent == 0)
            {
                dataNew.ParentTag = HandleParentTag.GenaretaParentTag(dataNew.Id);
                dataNew.ParentId = null;
            } else
            {
                var reportParent = await _context.ReportManager.FindAsync(request.IdParent);
                if (reportParent.Type == 1) // thư mục
                {
                    dataNew.ParentId = reportParent.Id;
                    dataNew.ParentTag = HandleParentTag.addIdToParentTag(reportParent.ParentTag, request.Id);
                } else // báo cáo
                {
                    dataNew.ParentId = reportParent.ParentId;
                    dataNew.ParentTag = HandleParentTag.ChangeIdInParentTag(reportParent.ParentTag, request.Id);
                }
                
            }

            var listChild = await _context.ReportManager.Where(x => x.ParentTag != parentTagOld && x.ParentTag.StartsWith(parentTagOld)).ToArrayAsync();

            foreach( var item in listChild)
            {
                item.ParentTag = item.ParentTag.Replace(parentTagOld, dataNew.ParentTag);
            }

            _context.ReportManager.UpdateRange(listChild);
            _context.ReportManager.Update(dataNew);
            //_context.Entry(dataOld).CurrentValues.SetValues(dataNew);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}

