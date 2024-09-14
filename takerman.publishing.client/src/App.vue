<template>
  <div id="mainContainer" class="container-fluid">
    <div class="row">
      <Header />
    </div>
    <div class="row">
      <router-view></router-view>
    </div>
    <div class="row">
      <Footer />
    </div>
  </div>
</template>
<script>
import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";

export default {
  components: { Header, Footer }
}
</script>

<style scoped lang="css">
#mainContainer {
  min-height: 700px;
}
</style>