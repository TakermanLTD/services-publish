<template>
    <div class="accordion" id="accordionPublications">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonPublications">
                <button class="accordion-button text-center" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePublications" aria-expanded="true" aria-controls="collapsePublications">
                    Platforms
                </button>
            </h2>
            <div id="collapsePublications" class="accordion-collapse collapse show" aria-labelledby="accordeonPublications" data-bs-parent="#accordionPublications">
                <div class="accordion-body">
                    <table class="table table-responsive text-center">
                        <thead class="thead-default">
                            <tr>
                                <th>Id</th>
                                <th>Platform</th>
                                <th>Client Url</th>
                                <th>Client Id</th>
                                <th>Client Secret</th>
                            </tr>
                            <tr>
                                <th scope="row"></th>
                                <th>
                                    <select class="form-select" v-model="this.platform">
                                        <option v-for="(platform, index) in this.platforms" :key="index" :value="platform.id">{{ platform.name }}</option>
                                    </select>
                                </th>
                                <th>
                                    <input class="form-control" ype="text" v-model="clientUrl">
                                </th>
                                <th>
                                    <input class="form-control" type="text" v-model="clientId">
                                </th>
                                <th>
                                    <input class="form-control" type="text" v-model="clientSecret">
                                </th>
                                <th>
                                    URLs
                                </th>
                                <th>
                                    <button @click="add" class="btn btn-success btn-sm"><i class="bi bi-plus-circle-fill"></i></button>
                                </th>
                                <th>
                                    <button @click="save()" class="btn btn-success btn-sm"><i class="bi bi-floppy"></i></button>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr :id="'mappings_' + mapping.id" v-for="(mapping, index) in mappings">
                                <td scope="row">{{ mapping.id }}</td>
                                <td>
                                    <select class="form-select" :value="Number(mapping.platform)">
                                        <option v-for="(platform, index) in platforms" :key="index" :value="index">{{ platform }}</option>
                                    </select>
                                </td>
                                <td>
                                    <input class="form-control" type="text" v-model="mapping.clientUrl">
                                </td>
                                <td>
                                    <input class="form-control" type="text" v-model="mapping.clientId">
                                </td>
                                <td>
                                    <input class="form-control" type="text" v-model="mapping.clientSecret">
                                </td>
                                <td>
                                    <div v-if="mapping.platformLinks && mapping.platformLinks.length > 0" v-for="(link, index) in mapping.platformLinks" :key="index">
                                        <a :href="link.url" target="_blank">{{ link.name }}</a>
                                    </div>
                                </td>
                                <td>
                                    <input type="checkbox" class="form-check-input platform" name="platform" :value="index" checked>
                                </td>
                                <td>
                                    <button @click="this.delete(mapping.id)" class="btn btn-danger btn-sm"><i class="bi bi-x-circle-fill"></i></button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="js">
export default {
    data() {
        return {
            platform: 0,
            clientUrl: '',
            clientId: '',
            clientSecret: '',
            platforms: [],
            mappings: []
        }
    },
    async mounted() {
        // await this.updateMappings();
        this.platforms = await (await fetch('/Platforms/GetAll')).json();
        if (this.platforms && this.platforms.length > 0) {
            this.platform = this.platforms[0].id;
        }
    },
    methods: {
        async updateMappings() {
            this.mappings = await (await fetch('ProjectPlatforms/GetAll?project=' + this.project + '&postType=' + this.postType)).json();
        },
        async save() {
            await fetch('ProjectPlatforms/UpdateAll', {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(this.mappings)
            });
            this.updateMappings();
        },
        async add() {
            let result = await (await fetch('ProjectPlatforms/Add', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    project: this.project,
                    postType: this.postType,
                    platform: Number(this.platform),
                    clientUrl: this.clientUrl,
                    clientId: this.clientId,
                    clientSecret: this.clientSecret
                })
            })).json();
            this.mappings.push(result);
        },
        async delete(id) {
            if (await fetch('ProjectPlatforms/Delete?id=' + id, { method: 'DELETE' })) {
                document.getElementById('mappings_' + id).remove();
            }
        },
    },
    watch: {
        async project(newProject) {
            await this.updateMappings();
        },
        async postType(newPostType) {
            await this.updateMappings();
        }
    },
    props: {
        project: Number,
        projects: Object,
        postType: Number,
        postTypes: Object
    }
}
</script>