using System.Collections.Generic;
using AutoMapper;
using Lekplatser.Api.Models;
using Lekplatser.Api.Repositories;
using Lekplatser.Dto;
using Nancy;
using Nancy.ModelBinding;

namespace Lekplatser.Api.Modules
{
    public class PlaygroundsModule : NancyModule
    {
        private readonly IPlaygroundsRepository _repository;

        public PlaygroundsModule(IPlaygroundsRepository repository) :base("/Playgrounds")
        {
            _repository = repository;

            Get["/GetAll"] = _ =>
            {
                Request.RequireAdmin();
                IEnumerable<PlaygroundEntity> playgroundEntities = _repository.GetAll();
                var ret = Mapper.Map<IEnumerable<PlaygroundEntity>, IEnumerable<Playground>>(playgroundEntities);
                return Response.AsJson(ret);
            };

            Get["/GetByLocation"] = param =>
            {
                var x = Request.Query;
                float lat, lng;
                if (!float.TryParse(Request.Query["lat"], out lat) ||
                    !float.TryParse(Request.Query["long"], out lng))
                {
                    return new Response
                    {
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

                return null;
            };

            Post["/Create"] = _ =>
            {
                var p = this.Bind<Playground>();
                var entity = Mapper.Map<Playground, PlaygroundEntity>(p);
                var id = _repository.Add(entity);
                return Response.AsJson(id.ToString());
            };
        }
    }
}