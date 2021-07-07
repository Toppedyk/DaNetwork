
import { AppState } from '../AppState'
import { api } from './AxiosService'

class PostsService {
  async getAllPosts() {
    const res = await api.get('api/posts')
    AppState.posts = res.data.reverse()
  }
}
export const postsService = new PostsService()
