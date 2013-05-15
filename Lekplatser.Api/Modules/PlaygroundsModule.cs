using System;
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
                //todo: support . in lat/long ?
                float lat = 0, lng= 0;
                if (!float.TryParse(Request.Query.lat, out lat) ||
                    !float.TryParse(Request.Query["long"], out lng))
                {
                    return new Response
                    {
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }

                var result = _repository.GetByLocation(lat, lng);

                var ret = Mapper.Map<IEnumerable<PlaygroundEntity>, IEnumerable<Playground>>(result);
                return Response.AsJson(ret);
            };

            Post["/Create"] = _ =>
            {
                //TODO: proximity logic
                var p = this.Bind<Playground>();
                if(p.Location == null ||
                    ((int)p.Location.Lat == 0 && (int)p.Location.Long == 0))
                    return new Response
                    {
                        StatusCode = HttpStatusCode.BadRequest
                    };

                var entity = Mapper.Map<Playground, PlaygroundEntity>(p);
                var id = _repository.Add(entity);
                return Response.AsJson(id.ToString());
            };

            Put["/Update"] = _ =>
            {
                throw new NotImplementedException();
            };
        }
    }
}