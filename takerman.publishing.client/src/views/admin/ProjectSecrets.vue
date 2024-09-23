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
                <th colspan="2">Value</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="(secret, index) in this.secretsData" :key="index">
                <td>{{ secret.name }}</td>
                <td colspan="2">
                    <input type="text" class="form-control" v-model="secret.value">
                </td>
            </tr>
        </tbody>
    </table>
</template>
<script lang="js">
export default {
    data() {
        return {
            selectedProject: 1,
            selectedPlatform: 1,
            projects: [],
            platforms: [],
            secretsData: []
        }
    },
    async mounted() {
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
            this.secretsData = await (await fetch('/ProjectSecrets/GetAll?platformId=' + this.selectedPlatform)).json();
        },
        async save() {
            let secrets = [];
            for (let i = 0; i < this.secretsData.length; i++) {
                const secret = this.secretsData[i];
                secrets.push({ key: secret.id, value: secret.value });
            }
            let secetsData = await (await fetch('/ProjectSecrets/Update', {
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
            let secrets = await (await fetch('/ProjectSecrets/Delete', {
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