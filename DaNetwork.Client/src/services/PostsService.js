
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

  async getPostsByAccountId(id) {
    const res = await api.get(`api/profiles/${id}/posts`)
    AppState.accountPosts = res.data.reverse()
  }

  async createPost(post) {
    await api.post('api/posts', post)
    await this.getAllPosts()
    await this.getPostsByAccountId(`api/profiles/${post.creatorId}/posts`)
  }
}
export const postsService = new PostsService()
