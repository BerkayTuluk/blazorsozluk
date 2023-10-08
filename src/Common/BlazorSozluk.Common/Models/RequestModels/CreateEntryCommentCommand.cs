using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Models.RequestModels;

public class CreateEntryCommentCommand : IRequest<Guid>
{
    public string Content { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid? EntryId { get; set; }

    public CreateEntryCommentCommand()
    {

    }

    public CreateEntryCommentCommand(string content, Guid createdById, Guid entryId)
    {
        Content = content;
        CreatedById = createdById;
        EntryId = entryId;
    }
}
