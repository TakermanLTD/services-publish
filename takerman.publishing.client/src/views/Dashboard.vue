<template>
	<h2 class="text-center page-heading">PUBLISH</h2>
	<div class="col">
		<label class="form-label text-center" for="ddlProject">Project</label>
		<select v-model="selectedProject" class="form-select" id="ddlProject">
			<option v-for="(project, index) in this.projects" :key="index" :value="project.id">{{ project.name }}</option>
		</select>
	</div>
	<div class="col">
		<label class="form-label text-center" for="ddlPostType">Post Type</label>
		<select v-model="selectedPostType" class="form-select" id="ddlPostType">
			<option v-for="(postType, index) in this.postTypes" :key="index" :value="postType.id">{{ postType.name }}</option>
		</select>
	</div>
	<br />
	<Platforms :project="Number(selectedProject)" :projects="this.projects" :postTypes="this.postTypes" />
	<Post :project="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<History :project="Number(selectedProject)" :postType="Number(selectedPostType)" />
</template>

<script lang="js">
import History from '@/components/History.vue';
import Platforms from '@/components/Platforms.vue';
import Post from '@/components/Post.vue';

export default {
	data() {
		return {
			selectedPostType: 1,
			selectedProject: 1,
			projects: [],
			postTypes: []
		}
	},
	async mounted() {
		this.projects = await (await fetch('Projects/GetAll')).json();
		if (this.projects.length > 0) {
			this.selectedProject = 1;
		}
		this.postTypes = await (await fetch('PostTypes/GetAll')).json();
		if (this.postTypes.length > 0) {
			this.selectedPostType = 1;
		}
	},
	components: {
		Post,
		Platforms,
		History
	}
}
</script>

<style scoped></style>
