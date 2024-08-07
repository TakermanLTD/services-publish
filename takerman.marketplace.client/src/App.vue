<template>
  <section class="container">
    <hgroup>
      <h1>Marketplace</h1>
    </hgroup>
  </section>
  <PublishItem />
</template>
<script>
import PublishItem from "./components/PublishItem.vue";

export default {
  components: { PublishItem }
}
</script>