using DaNetwork.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace DaNetwork.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ProfilesController : ControllerBase
    {
        private readonly AccountService _serviceAcct;
        private readonly CommentsService _serviceComm;
        private readonly PostsService _servicePost; 
        private readonly LikesService _serviceLike;
        
        
    }
}