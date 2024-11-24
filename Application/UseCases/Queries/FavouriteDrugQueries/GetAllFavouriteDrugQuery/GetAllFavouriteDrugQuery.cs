using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavouriteDrugQueries.GetAllFavouriteDrugQuery;

/// <summary>
/// Получение всех FavouriteDrug
/// </summary>
public record GetAllFavouriteDrugQuery : IRequest<List<FavouriteDrug>>;