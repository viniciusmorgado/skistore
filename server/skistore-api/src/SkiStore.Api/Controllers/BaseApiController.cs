using Microsoft.AspNetCore.Mvc;
using SkiStore.Api.RequestHelpers;
using SkiStore.Core.Base.Entities;
using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected async Task<ActionResult> CreatedPagedResult<T>(IGenericRepository<T> repository, ISpecification<T> specification, int pageIndex, int pageSize) where T : BaseEntity
    {
        return Ok(new
            Pagination<T>(
                  pageIndex
                , pageSize
                , await repository.CountAsync(specification)
                , await repository.GetAllWithSpec(specification)
            )
        );
    }
}
