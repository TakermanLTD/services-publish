<template>
    <table class="table">
        <thead>
            <tr class="table-primary">
                <th style="width: 25%;">
                    <select v-model="selectedProject" class="form-select" id="ddlProject">
                        <option v-for="(project, index) in this.projects" :key="index" :value="project.id">{{ project.name }}</option>
                    </select>
                </th>
                <th>
                    <select v-model="selectedPostType" class="form-select" id="ddlPostType">
                        <option v-for="(postType, index) in this.postTypes" :key="index" :value="postType.id">{{ postType.name }}</option>
                    </select>
                </th>
                <th>
                    <select @change="refresh" v-model="selectedPlatform" class="form-select" id="ddlPlatforms">
                        <option v-for="(platform, index) in this.platforms" :key="index" :value="platform.id">{{ platform.name }}</option>
                    </select>
                </th>
                <th>
                    <button @click="this.save()" type="button" class="btn btn-success">
                        <i class="fa-solid fa-save"></i>
                    </button>
                    <button @click="this.delete()" type="button" class="btn btn-danger">
                        <i class="fa-solid fa-minus"></i>
                    </button>
                </th>
            </tr>
            <tr class="table-primary">
                <th>Name</th>
                <th colspan="3">Value</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="(platformSecret, index) in this.platformSecrets" :key="index">
                <td>{{ platformSecret.name }}</td>
                <td colspan="3">
                    <input type="text" class="form-control" v-model="platformSecret.value">
                </td>
            </tr>
        </tbody>
    </table>
</template>
<script lang="js">
export default {
    data() {
        return {
            selectedPostType: 1,
            selectedProject: 1,
            selectedPlatform: 1,
            projects: [],
            postTypes: [],
            platforms: [],
            platformSecrets: []
        }
    },
    async mounted() {
        this.postTypes = await (await fetch('/PostTypes/GetAll')).json();
        if (this.postTypes && this.postTypes.length > 0) {
            this.selectedPostType = this.postTypes[0].id;
        }
        this.projects = await (await fetch('/Projects/GetAll')).json();
        if (this.projects && this.projects.length > 0) {
            this.selectedProject = this.projects[0].id;
        }
        this.platforms = await (await fetch('/Platforms/GetAll')).json();
        if (this.platforms && this.platforms.length > 0) {
            this.selectedPlatform = this.platforms[0].id;
        }
        await this.refresh();
    },
    methods: {
        async refresh() {
            this.platformSecrets = await (await fetch('/PlatformSecrets/GetAll?platformId=' + this.selectedPlatform)).json();
        },
        async save() {
            let secrets = [];
            for (let i = 0; i < this.platformSecrets.length; i++) {
                const platformSecret = this.platformSecrets[i];
                secrets.push({ key: platformSecret.id, value: platformSecret.value });
            }
            let projectPlatformSecrets = await (await fetch('/ProjectPlatforms/Update', {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    projectId: this.selectedProject,
                    platformId: this.selectedPlatform,
                    postTypeId: this.selectedPostType,
                    secrets: secrets
                })
            })).json();
            this.platformName = '';
            await this.refresh();
        },
        async delete() {
            let projectPlatformSecrets = await (await fetch('/ProjectPlatforms/Delete', {
                method: "DELETE",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    projectId: this.selectedProject,
                    platformId: this.selectedPlatform,
                    postTypeId: this.selectedPostType,
                })
            })).json();
            await this.refresh();
        }
    },
}
</script>