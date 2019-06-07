module.exports = {
  publicPath: process.env.NODE_ENV === 'production' ? '/web-ui/' : '/',
  devServer: { //
    proxy: 'http://localhost:53130',
  },
}