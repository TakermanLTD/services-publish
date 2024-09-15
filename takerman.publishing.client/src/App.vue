<template>
  <div id="mainContainer" class="container-fluid">
    <div class="row">
      <Header />
    </div>
    <div style="width: 90%; margin-left: auto; margin-right: auto;" class="row">
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
  components: { Header, Footer },
  metaInfo: {
    title: 'common.title',
    titleTemplate: '%s | ' + 'common.host',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { name: 'description', content: 'common.description' },
      { name: 'keywords', content: 'common.keywords' }
    ]
  }
}
</script>

<style scoped lang="css">
#mainContainer {
  min-height: 700px;
}
</style>