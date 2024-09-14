<template>
    <div class="accordion" id="accordionTweet">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonTweet">
                <button class="accordion-button text-center collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTweet" aria-expanded="false" aria-controls="collapseTweet">
                    Publications
                </button>
            </h2>
            <div id="collapseTweet" class="accordion-collapse collapse" aria-labelledby="accordeonTweet" data-bs-parent="#accordionTweet">
                <div class="accordion-body">
                    <table class="table table-responsive">
                        <tr>
                            <th>ID</th>
                            <th>Description</th>
                            <th></th>
                        </tr>
                        <tr v-for="(publication, index) in this.publications" :key="index">
                            <td>{{ publication.id }}</td>
                            <td>{{ publication.postDescription }}</td>
                            <td>
                                <button @click="this.delete(publication.id)" class="btn btn-danger"><i class="bi bi-x-circle-fill"></i></button>
                                <button @click="this.fill(publication.id)" class="btn btn-info"><i class="bi bi-arrow-up-square-fill"></i></button>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonTweet">
                <button class="accordion-button text-center" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTweet" aria-expanded="true" aria-controls="collapseTweet">
                    Post
                </button>
            </h2>
            <div id="collapseTweet" class="accordion-collapse collapse show" aria-labelledby="accordeonTweet" data-bs-parent="#accordionTweet">
                <div class="accordion-body">
                    <div class="form-group">
                        <label for="postDescription">Content</label>
                        <editor api-key="u43iacolfm6l254nstw823zqhc7402lhndz1s3fd9tac7u51" id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></editor>
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
            publications: []
        }
    },
    components: {
        editor: Editor
    },
    methods: {
        async refresh() {
            this.publications = await (await fetch('Blog/GetAll?project=' + this.project)).json();
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
                PostDescription: this.postDescription
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Tweet/Publish', requestOptions);
            await this.refresh();
        },
        async delete(id) {
            await fetch('Tweet/Delete?id=' + id, { method: "DELETE" });
            await this.refresh();
        },
        async fill(id) {
            let publication = await fetch('Tweet/Get?id=' + id);
            this.postName = publication.postName;
            this.postDescription = publication.postDescription;
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