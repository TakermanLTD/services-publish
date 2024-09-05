<template>
    <div class="row">
        <div class="col">
            <div class="form-group">
                <div v-for="(project, index) in projects" class="form-check">
                    <label class="form-check-label">
                        <input @click="updatePlatforms"
                               v-model="selectedProject"
                               type="radio"
                               class="form-check-input"
                               name="project"
                               :value="project.id" />
                        {{ project.name }}
                    </label>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="form-group">
                <label for="ddlPostType">Post Type</label>
                <select v-model="selectedPostType" class="form-control" name="ddlPostType" id="ddlPostType" @change="updatePlatforms">
                    <option v-for="(postType, index) in postTypes" :key="index">{{ postType }}</option>
                </select>
            </div>
        </div>
        <div class="col">
            <div v-for="(platform, index) in platforms" :key="index" class="form-check">
                <label class="form-check-label">
                    <input type="checkbox" class="form-check-input" name="platform" id="platform" :value="index" checked>
                    {{ platform }}
                </label>
            </div>
        </div>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            selectedPostType: 1,
            selectedProject: 0,
            projects: [],
            postTypes: [],
            platforms: []
        }
    },
    async mounted() {
        this.projects = await (await fetch('Home/GetProjects')).json();
        this.postTypes = await (await fetch('Home/GetEnum?enumName=PostType')).json();
        this.updatePlatforms();
    },
    methods: {
        async updatePlatforms() {
            this.platforms = await (await fetch('Home/GetPlatforms?project=' + this.selectedProject + '&postType=' + this.selectedPostType)).json();
        }
    }
}
</script>