<template>
  <div class="container">
    <div class="row text-center align-center">
      <p>{{ this.user.nickname }}</p>
      <img class="img" style="width: 150px; height: 120px;" :src="this.user.picture" />
      <p>{{ this.user.email_verified ? 'Verified' : 'Not Verified' }}</p>
    </div>
  </div>
</template>

<script lang="js">
export default {
  data() {
    return {
      user: this.$auth0.user
    }
  }
}
</script>
