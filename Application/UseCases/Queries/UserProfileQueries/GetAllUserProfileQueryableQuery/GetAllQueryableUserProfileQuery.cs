using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace Application.UseCases.Queries.UserProfileQueries.GetAllUserProfileQueryableQuery;

/// <summary>
/// Получение всех Query UserProfile
/// </summary>
/// <param name="QueryOptions">Опции Query.</param>
public record GetAllQueryableUserProfileQuery(ODataQueryOptions<UserProfile> QueryOptions) : IRequest<IQueryable<UserProfile>>;