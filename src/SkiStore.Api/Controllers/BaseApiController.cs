using Microsoft.AspNetCore.Mvc;
using SkiStore.Api.RequestHelpers;
using SkiStore.Core.Base.Entities;
using SkiStore.Core.Base.Interfaces;
using SkiStore.Infrastructure.Data.Base.Repositories;

namespace SkiStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected async Task<ActionResult> CreatedPagedResult<T>(IGenericRepository<T> repository, ISpecification<T> specification, int pageIndex, int pageSize) where T : BaseEntity
    {
        var items = await repository.GetAllWithSpec(specification);
        var count = await repository.CountAsync(specification);
        var pagination = new Pagination<T>(pageIndex, pageSize, count, items);

        return Ok(pagination);
    }
}
