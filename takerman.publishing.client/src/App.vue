<template>
  <header>
    <hgroup>
      <h2 class="text-center">PUBLISHER</h2>
    </hgroup>
    <hr />
  </header>
  <div id="mainContainer" class="container">
    <router-view></router-view>
  </div>
  <footer class="text-center">
    <hr />
    Copyright Takerman 2024
  </footer>
</template>
<script>
import Home from "./views/Home.vue";

export default {
  components: { Home }
}
</script>

<style scoped lang="css">
#mainContainer {
  min-height: 700px;
}
</style>