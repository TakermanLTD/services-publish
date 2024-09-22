<template>
    <div class="accordion" id="accordionHistory">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonHistory">
                <button class="accordion-button text-center collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseHistory" aria-expanded="false" aria-controls="collapseHistory">
                    History
                </button>
            </h2>
            <div id="collapseHistory" class="accordion-collapse collapse" aria-labelledby="accordeonHistory" data-bs-parent="#accordionHistory">
                <div class="accordion-body">
                    <table class="table table-responsive text-center">
                        <tbody>
                            <tr>
                                <th>ID</th>
                                <th>Name</th>
                                <th>Content</th>
                                <th width="100px"></th>
                            </tr>
                            <tr v-for="(publication, index) in this.publications" :key="index">
                                <td>{{ publication.id }}</td>
                                <td>{{ publication.postName }}</td>
                                <td>{{ publication.postDescription.substring(0, 80) }}</td>
                                <td class="text-right" width="100px">
                                    <button @click="this.delete(publication.id)" class="btn btn-danger"><i class="bi bi-x-circle-fill"></i></button>
                                    <button @click="this.fill(publication.id)" class="btn btn-info"><i class="bi bi-arrow-up-square-fill"></i></button>
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
            publications: []
        }
    },
    methods: {
        async refresh() {
            this.publications = await (await fetch(this.postType + '/GetAll?project=' + this.project)).json();
        },
        async mounted() {
            await this.refresh();
        }
    },
    watch: {
        async project(newProject) {
            await this.refresh();
        },
        async postType(newPostType) {
            await this.refresh();
        }
    },
    props: {
        project: Number,
        postType: Number
    }
}
</script>