<template>
	<h2 class="text-center page-heading">PUBLISH</h2>
	<div class="row">
		<div class="col">
			<select v-model="selectedProject" class="form-control" id="ddlProject" @change="updatePlatforms">
				<option v-for="(project, index) in projects" :key="index" :value="project.id">{{ project.name }}</option>
			</select>
		</div>
		<div class="col">
			<select v-model="selectedPostType" class="form-control" id="ddlPostType" @change="updatePlatforms">
				<option v-for="(postType, index) in postTypes" :key="index" :value="index">{{ postType }}</option>
			</select>
		</div>
	</div>
	<br />
	<PublicationVideo v-if="selectedPostType == 1" :projectId="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationShort v-else-if="selectedPostType == 2" :projectId="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationBlogpost v-else-if="selectedPostType == 3" :projectId="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationTweet v-else-if="selectedPostType == 4" :projectId="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationSelling v-else-if="selectedPostType == 5" :projectId="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<PublicationPicture v-else-if="selectedPostType == 6" :projectId="Number(selectedProject)" :postType="Number(selectedPostType)" />
	<Platforms :projectId="selectedProject" :postType="selectedPostType" />
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
			postTypes: [],
			platforms: []
		}
	},
	async mounted() {
		this.projects = await (await fetch('Home/GetProjects')).json();
		if (this.projects.length > 0) {
			this.selectedProject = 1;
		}
		this.postTypes = await (await fetch('Home/GetEnum?enumName=PostType')).json();
		if (this.postTypes.length > 0) {
			this.selectedPostType = 1;
		}
		this.updatePlatforms();
	},
	methods: {
		async updatePlatforms() {
			this.platforms = await (await fetch('Home/GetPlatformsFiltered?project=' + this.selectedProject + '&postType=' + this.selectedPostType)).json();
		}
	},
	components: {
		PublicationVideo,
		PublicationShort,
		PublicationBlogpost,
		PublicationTweet,
		PublicationSelling,
		PublicationPicture
	}
}
</script>

<style scoped></style>
