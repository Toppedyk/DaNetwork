
import { AppState } from '../AppState'
import { api } from './AxiosService'

class PostsService {
  async getAllPosts() {
    const res = await api.get('api/posts')
    AppState.posts = res.data.reverse()
  }

  async getPostById(id) {
    const res = await api.get(`api/posts/${id}`)
    AppState.activePost = res.data
  }
}
export const postsService = new PostsService()
