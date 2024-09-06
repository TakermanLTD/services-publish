<template>
    <h2 class="text-center page-heading">Admin</h2>
    <table class="table table-striped table-responsive">
        <thead class="thead-default">
            <tr>
                <th>Id</th>
                <th>Project</th>
                <th>Post type</th>
                <th>Platform</th>
                <th>Client Url</th>
                <th>Client Id</th>
                <th>Client Secret</th>
                <th>Limit</th>
            </tr>
            <tr>
                <th scope="row"></th>
                <th>
                    <select :value="this.new.projectId">
                        <option v-for="(project, index) in projects" :key="index" :value="project.id">{{ project.name }}</option>
                    </select>
                </th>
                <th>
                    <select :value="this.new.postType">
                        <option v-for="(postType, index) in postTypes" :key="index" :value="index">{{ postType }}</option>
                    </select>
                </th>
                <th>
                    <select :value="this.new.platform">
                        <option v-for="(platform, index) in platforms" :key="index" :value="index">{{ platform }}</option>
                    </select>
                </th>
                <th>
                    <input type="text" v-model="this.new.clientUrl">
                </th>
                <th>
                    <input type="text" v-model="this.new.clientId">
                </th>
                <th>
                    <input type="text" v-model="this.new.clientSecret">
                </th>
                <th>
                    <input type="number" v-model="this.new.limit">
                </th>
                <th>
                    <button class="btn btn-success btn-sm">+</button>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="(mapping, index) in mappings">
                <td scope="row">{{ mapping.id }}</td>
                <td>
                    <select :value="mapping.projectId">
                        <option v-for="(project, index) in projects" :key="index" :value="project.id">{{ project.name }}</option>
                    </select>
                </td>
                <td>
                    <select :value="mapping.postType">
                        <option v-for="(postType, index) in postTypes" :key="index" :value="index">{{ postType }}</option>
                    </select>
                </td>
                <td>
                    <select :value="mapping.platformConfigData.platform">
                        <option v-for="(platform, index) in platforms" :key="index" :value="index">{{ platform }}</option>
                    </select>
                </td>
                <td>
                    <input type="text" v-model="mapping.platformConfigData.clientUrl">
                </td>
                <td>
                    <input type="text" v-model="mapping.platformConfigData.clientId">
                </td>
                <td>
                    <input type="text" v-model="mapping.platformConfigData.clientSecret">
                </td>
                <td>
                    <input type="number" v-model="mapping.platformConfigData.limit">
                </td>
                <div>
                    <button class="btn btn-danger btn-sm">X</button>
                </div>
            </tr>
        </tbody>
    </table>
</template>
<script lang="js">
export default {
    data() {
        return {
            new: {
                projectId: 0,
                postType: 0,
                platform: 0,
                clientUrl: '',
                clientId: '',
                clientSecret: '',
                Limit: 0
            },
            mappings: [],
            projects: [],
            postTypes: [],
            platforms: []
        }
    },
    async mounted() {
        this.mappings = await (await fetch('Home/GetPlatforms')).json();
        this.projects = await (await fetch('Home/GetProjects')).json();
        this.postTypes = await (await fetch('Home/GetEnum?enumName=PostType')).json();
        this.platforms = await (await fetch('Home/GetEnum?enumName=Platform')).json();
        debugger;
    },
    methods: {
    }
}
</script>