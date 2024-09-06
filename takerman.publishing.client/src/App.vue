<template>
  <Header />
  <div id="mainContainer" class="container">
    <router-view></router-view>
  </div>
  <hr />
  <Footer />
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