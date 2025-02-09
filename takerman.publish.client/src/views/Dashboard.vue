<template>
	<h2 class="text-center page-heading">PUBLISH</h2>
	<div class="col">
		<label class="form-label text-center" for="ddlProject">Project</label>
		<select @change="refresh" v-model="selectedProject" class="form-select" id="ddlProject">
			<option v-for="(project, index) in this.projects" :key="index" :value="project.id">{{ project.name }}</option>
		</select>
	</div>
	<div class="col">
		<label class="form-label text-center" for="ddlPostType">Post Type</label>
		<select @change="refresh" v-model="selectedPostType" class="form-select" id="ddlPostType">
			<option v-for="(postType, index) in this.postTypes" :key="index" :value="postType.id">{{ postType.name }}</option>
		</select>
	</div>
	<br />
	<div class="accordion" id="accordionPublications">
		<div class="accordion-item">
			<h2 class="accordion-header" id="accordeonPublications">
				<button class="accordion-button text-center" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePublications" aria-expanded="true" aria-controls="collapsePublications">
					Platforms
				</button>
			</h2>
			<div id="collapsePublications" class="accordion-collapse collapse show" aria-labelledby="accordeonPublications" data-bs-parent="#accordionPublications">
				<div class="accordion-body">
					<div class="list-group">
						<label v-for="(platform, index) in this.platforms" :key="index" :id="'secret' + platform.id" class="list-group-item">
							<input class="form-check-input me-1" type="checkbox" :value="platform.id" />
							{{ platform.name }}
						</label>
					</div>
				</div>
			</div>
		</div>
	</div>
	<Post :project="Number(selectedProject)" :postType="Number(selectedPostType)" :postId="Number(selectedPost)" />
	<History :project="Number(selectedProject)" :postType="Number(selectedPostType)" />
</template>

<script lang="js">
import History from '@/components/History.vue';
import Post from '@/components/Post.vue';

export default {
	data() {
		return {
			selectedPostType: 1,
			selectedProject: 1,
			selectedPost: 0,
			projects: [],
			postTypes: [],
			platforms: []
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
		this.refresh();
	},
	methods: {
		async refresh() {
			this.platforms = await (await fetch('PlatformPostTypes/GetAvailable?projectId=' + this.selectedProject + '&postTypeId=' + this.selectedPostType)).json();
		}
	},
	components: {
		Post,
		History
	}
}
</script>

<style scoped></style>
