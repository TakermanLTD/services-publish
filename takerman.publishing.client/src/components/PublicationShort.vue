<template>
    <div class="accordion" id="accordionShort">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonShort">
                <button class="accordion-button text-center collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseShort" aria-expanded="false" aria-controls="collapseShort">
                    Publications
                </button>
            </h2>
            <div id="collapseShort" class="accordion-collapse collapse" aria-labelledby="accordeonShort" data-bs-parent="#accordionShort">
                <div class="accordion-body">
                    <table class="table table-responsive">
                        <tbody>
                            <tr>
                                <th>ID</th>
                                <th>Description</th>
                                <th>Short</th>
                                <th></th>
                            </tr>
                            <tr v-for="(publication, index) in this.publications" :key="index">
                                <td>{{ publication.id }}</td>
                                <td>{{ publication.postDescription }}</td>
                                <td>{{ publication.postShort }}</td>
                                <td>
                                    <button @click="this.delete(publication.id)" class="btn btn-danger"><i class="bi bi-x-circle-fill"></i></button>
                                    <button @click="this.fill(publication.id)" class="btn btn-info"><i class="bi bi-arrow-up-square-fill"></i></button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonShort">
                <button class="accordion-button text-center" type="button" data-bs-toggle="collapse" data-bs-target="#collapseShort" aria-expanded="true" aria-controls="collapseShort">
                    Post
                </button>
            </h2>
            <div id="collapseShort" class="accordion-collapse collapse show" aria-labelledby="accordeonShort" data-bs-parent="#accordionShort">
                <div class="accordion-body">
                    <div class="form-group">
                        <label for="postDescription">Description</label>
                        <editor api-key="u43iacolfm6l254nstw823zqhc7402lhndz1s3fd9tac7u51" id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></editor>
                    </div>
                    <br />
                    <div class="custom-file mt-3 mb-3">
                        <input type="file" class="custom-file-input form-control" id="short" style="border: 1px solid black" />
                    </div>
                    <div class="form-group">
                        <button @click="publish" class="btn btn-success text-center">Publish</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script lang="js">
import Editor from '@tinymce/tinymce-vue';
export default {
    data() {
        return {
            postDescription: '',
            postShort: [],
            publications: []
        }
    },
    components: {
        editor: Editor
    },
    methods: {
        async refresh() {
            this.publications = await (await fetch('Short/GetAll?project=' + this.project)).json();
        },
        async mounted() {
            await this.refresh();
        },
        async publish() {
            let platforms = [];
            let platfromsDom = document.querySelectorAll('.platform:checked');
            for (let i = 0; i < platfromsDom.length; i++) {
                platforms.push(Number(platfromsDom[i].value));
            }
            const data = JSON.stringify({
                Project: this.project,
                Type: this.postType,
                Platforms: platforms,
                PostDescription: this.postDescription,
                PostShort: this.postShort
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Short/Publish', requestOptions);
            await this.refresh();
        },
        async delete(id) {
            await fetch('Short/Delete?id=' + id, { method: "DELETE" });
            await this.refresh();
        },
        async fill(id) {
            let publication = await fetch('Short/Get?id=' + id);
            this.postDescription = publication.postDescription;
            this.postShort = publication.postShort;
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