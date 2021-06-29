using DaNetwork.Server.Services;

namespace DaNetwork.Server.Controllers
{
    public class LikesController
    {
        private readonly AccountService _serviceAcct;
        private readonly CommentsService _serviceComm;
        private readonly PostsService _servicePost; 
        private readonly LikesService _serviceLike;
    }
}