<template>
	<h2 class="text-center page-heading">PUBLISH</h2>
	<div class="col">
		<label class="form-label text-center" for="ddlProject">Project</label>
		<select v-model="selectedProject" class="form-select" id="ddlProject">
			<option v-for="(project, index) in projects" :key="index" :value="index">{{ project }}</option>
		</select>
	</div>
	<div class="col">
		<label class="form-label text-center" for="ddlPostType">Post Type</label>
		<select v-model="selectedPostType" class="form-select" id="ddlPostType">
			<option v-for="(postType, index) in postTypes" :key="index" :value="index">{{ postType }}</option>
		</select>
	</div>
	<br />
	<Platforms :project="Number(selectedProject)" :postType="Number(selectedPostType)" :projects="projects" :postTypes="postTypes" />
	<PublicationVideo v-if="selectedPostType == 1" :project="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationShort v-else-if="selectedPostType == 2" :project="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationBlogpost v-else-if="selectedPostType == 3" :project="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationTweet v-else-if="selectedPostType == 4" :project="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationSelling v-else-if="selectedPostType == 5" :project="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationPicture v-else-if="selectedPostType == 6" :project="Number(selectedProject)" :postType="Number(selectedPostType)" />
</template>

<script lang="js">
import Platforms from '@/components/Platforms.vue';
import PublicationBlogpost from '@/components/PublicationBlogpost.vue';
import PublicationPicture from '@/components/PublicationPicture.vue';
import PublicationSelling from '@/components/PublicationSelling.vue';
import PublicationShort from '@/components/PublicationShort.vue';
import PublicationTweet from '@/components/PublicationTweet.vue';
import PublicationVideo from '@/components/PublicationVideo.vue';

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
		this.projects = await (await fetch('Home/GetEnum?enumName=Project')).json();
		if (this.projects.length > 0) {
			this.selectedProject = 1;
		}
		this.postTypes = await (await fetch('Home/GetEnum?enumName=PostType')).json();
		if (this.postTypes.length > 0) {
			this.selectedPostType = 1;
		}
	},
	components: {
		PublicationVideo,
		PublicationShort,
		PublicationBlogpost,
		PublicationTweet,
		PublicationSelling,
		PublicationPicture,
		Platforms
	}
}
</script>

<style scoped></style>
