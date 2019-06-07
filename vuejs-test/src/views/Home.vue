<template>
  <div class="home">
    <div v-show="error" class="red">
      서버에 에러가 있습니다.
    </div>
    <table>
      <tr>
        <td style="width: 400px">제목</td>
        <td style="width: 100px">일자</td>
        <td></td>
      </tr>
      <tr v-for="board in data" :key="board.BOARD_IDX">
        <td>{{board.TITLE}}</td>
        <td>{{board.WDATE}}</td>
        <td><button>수정</button><button>삭제</button></td>
      </tr>
    </table>
    <button @click="linkToWrite()"> 신규 </button>
  </div>
</template>

<script>
import axios from 'axios'

// @ is an alias to /src

export default {
  name: 'home',
  data() {
    return {
      data: null,
      error: false,
      errorMsg: ''
    }
  },
  components: {
  },
  mounted() {
    axios.get('/api/BoardNotice/GetBoardList')
      .then((res) => {
        this.data = res.data
        this.error = false
      })
      .catch((err) => {
        this.error = true
        this.errorMsg = err.message;
      })
  },
  methods: {
    linkToWrite() {
      this.$router.push('write')
    }
  }
}
</script>

<style scoped>
  .red {
    color: red;
  }
</style>
