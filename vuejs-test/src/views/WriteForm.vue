<template>
  <div>
    <div>
      <lable for="title">Title</lable>
      <input id="title" :value="title" @input="setTitle"/>
    </div>
    <div>
      <button @click="save()">저장</button>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      title: ''
    }
  },
  mounted() {

  },
  methods : {
    setTitle(e) {
      this.title = e.target.value
    },
    save() {
      axios.post('/api/BoardNotice/SaveBoardNote', { TITLE: this.title })
        .then((res) => {
          this.$router.push({name: 'home'})
        })
        .catch((err) => {
          
        })
    }
  }
}
</script>

<style scoped>

</style>