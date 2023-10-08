using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Application.Features.Queries.GetEntries;

public class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, List<GetEntriesViewModel>>
{
    private readonly IEntryRepository entryRepository;
    private readonly IMapper mapper;

    public GetEntriesQueryHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        this.entryRepository = entryRepository;
        this.mapper = mapper;
    }

    public async Task<List<GetEntriesViewModel>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = entryRepository.AsQueryable();//veritabanına gitmeden kendi sorgularımızı yazabilmemiz için kullanılır

        if (request.TodaysEntries)
        {
            query = query
                .Where(i => i.CreateDate >= DateTime.Now.Date)
                .Where(i => i.CreateDate <= DateTime.Now.AddDays(1).Date);
        }

        query = query.Include(i => i.EntryComments) //Sorguya EntryComments tablosundaki uyuşan verileride kat
                     .OrderBy(i => Guid.NewGuid()) // Belli bir kurala göre sırala
                     .Take(request.Count); // Take metodu belirlenen sayı kadar veri tabanından veri çeker

        return await query.ProjectTo<GetEntriesViewModel>(mapper.ConfigurationProvider).ToListAsync();
    }
}
