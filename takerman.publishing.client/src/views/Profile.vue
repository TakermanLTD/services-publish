<template>
  <div class="container">
    <div class="row align-items-center profile-header">
      <div class="col-md-2 mb-3">
        <img :src="this.user?.picture" alt="User's profile picture" class="rounded-circle img-fluid profile-picture" />
      </div>
      <div class="col-md text-center text-md-left">
        <h2>{{ this.user?.name }}</h2>
        <p class="lead text-muted">{{ this.user?.email }}</p>
      </div>
    </div>

    <div class="row">
      <span>{{ JSON.stringify(this.user, null, 2) }}</span>
    </div>
  </div>
</template>

<script lang="js">
import { useAuth0 } from '@auth0/auth0-vue';

export default {
  data() {
    const auth0 = useAuth0();
    return {
      user: auth0.user
    }
  }
}
</script>
