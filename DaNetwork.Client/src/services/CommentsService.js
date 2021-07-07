const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class CommentsService {
  async getCommentsByPostId(id) {
    const res = await api.get(`api/posts/${id}/comments`)
    AppState.comments = res.data.reverse()
  }
}
export const commentsService = new CommentsService()
