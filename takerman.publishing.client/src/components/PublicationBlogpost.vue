<template>
    <div class="accordion" id="accordionBlogpost">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonBlogpost">
                <button class="accordion-button text-center collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseBlogpost" aria-expanded="false" aria-controls="collapseBlogpost">
                    Publications
                </button>
            </h2>
            <div id="collapseBlogpost" class="accordion-collapse collapse" aria-labelledby="accordeonBlogpost" data-bs-parent="#accordionBlogpost">
                <div class="accordion-body">
                    <table class="table table-responsive text-center">
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
                    </table>
                </div>
            </div>
        </div>
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonBlogpost">
                <button class="accordion-button text-center" type="button" data-bs-toggle="collapse" data-bs-target="#collapseBlogpost" aria-expanded="true" aria-controls="collapseBlogpost">
                    Post
                </button>
            </h2>
            <div id="collapseBlogpost" class="accordion-collapse collapse show" aria-labelledby="accordeonBlogpost" data-bs-parent="#accordionBlogpost">
                <div class="accordion-body">
                    <div class="form-group">
                        <label for="postName">Name</label>
                        <input type="text" id="postName" class="form-control" placeholder="Name" aria-describedby="postName" v-model="postName" />
                    </div>
                    <br />
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
            postName: '',
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
            tinymce.init({
                selector: 'textarea',  // change this value according to your HTML
                skin: 'oxide-dark',
                content_css: 'dark'
            });
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
                PostName: this.postName,
                PostDescription: this.postDescription
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Blog/Publish', requestOptions);
            await this.refresh();
        },
        async delete(id) {
            await fetch('Blog/Delete?id=' + id, { method: "DELETE" });
            await this.refresh();
        },
        async fill(id) {
            let publication = await fetch('Blog/Get?id=' + id);
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