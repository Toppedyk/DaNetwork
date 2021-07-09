const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class CommentsService {
  async getCommentsByPostId(id) {
    const res = await api.get(`api/posts/${id}/comments`)
    AppState.comments = res.data.reverse()
  }

  async getCommentById(id) {
    const res = await api.get(`api/comments/${id}`)
    AppState.activeComment = res.data
  }

  async createComment(comment) {
    await api.post('api/comments', comment)
    this.getCommentsByPostId(comment.postId)
  }
}
export const commentsService = new CommentsService()
