<template>
	<h2 class="text-center page-heading">Home</h2>
	<Filter />
	<br />
	<hr />
	<Publication />
</template>

<script lang="js">
import Filter from '@/components/Filter.vue';
import Publication from '@/components/Publication.vue';

export default {
	components: { Filter, Publication }
}
</script>

<style scoped></style>
