<template>
    <h3 class="text-center page-heading">Project Platforms</h3>
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
                    <select v-model="this.new.projectId">
                        <option v-for="(project, index) in projects" :key="index" :value="project.id">{{ project.name }}</option>
                    </select>
                </th>
                <th>
                    <select v-model="this.new.postType">
                        <option v-for="(postType, index) in postTypes" :key="index" :value="index">{{ postType }}</option>
                    </select>
                </th>
                <th>
                    <select v-model="this.new.platform">
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
                    <button @click="add(this.new)" class="btn btn-success btn-sm">+</button>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr :id="'mappings_' + mapping.id" v-for="(mapping, index) in mappings">
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
                    <select :value="mapping.platform">
                        <option v-for="(platform, index) in platforms" :key="index" :value="index">{{ platform }}</option>
                    </select>
                </td>
                <td>
                    <input type="text" v-model="mapping.clientUrl">
                </td>
                <td>
                    <input type="text" v-model="mapping.clientId">
                </td>
                <td>
                    <input type="text" v-model="mapping.clientSecret">
                </td>
                <td>
                    <input type="number" v-model="mapping.limit">
                </td>
                <td>
                    <input type="checkbox" class="form-check-input platform" name="platform" :value="index" checked>
                </td>
                <div>
                    <button @click="this.delete(mapping.id)" class="btn btn-danger btn-sm">X</button>
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
                limit: 0
            },
            mappings: [],
        }
    },
    async mounted() {
        this.mappings = await (await fetch('Home/GetPlatforms?project=' + this.projectId + '&postType=' + this.postType)).json();
    },
    methods: {
        async add(model) {
            let result = await (await fetch('Admin/AddPlatformToProject', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(model)
            })).json();
            this.mappings.push(result);
            this.new = {
                projectId: 0,
                postType: 0,
                platform: 0,
                clientUrl: '',
                clientId: '',
                clientSecret: '',
                limit: 0
            };
        },
        async delete(id) {
            if (await fetch('Admin/DeleteProjectToPlatform?id=' + id, { method: 'DELETE' })) {
                document.getElementById('mappings_' + id).remove();
            }
        },
    },
    props: {
        projectId: Number,
        postType: Number
    }
}
</script>