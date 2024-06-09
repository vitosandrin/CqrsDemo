using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Infrastructure.Repositories;

public class UnityOfWork(AppDbContext context, IMemberRepository memberRepository) : IUnityOfWork, IDisposable
{
    private IMemberRepository? _memberRepository = memberRepository;
    private readonly AppDbContext _context = context;

    public IMemberRepository MemberRepository
    {
        get
        {
            return _memberRepository ??= new MemberRepository(_context);
        }
    }


    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
