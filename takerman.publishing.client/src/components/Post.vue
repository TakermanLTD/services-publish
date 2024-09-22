<template>
    <div class="accordion" id="accordionPost">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonPost">
                <button class="accordion-button text-center" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePost" aria-expanded="true" aria-controls="collapsePost">
                    Post
                </button>
            </h2>
            <div id="collapsePost" class="accordion-collapse collapse show" aria-labelledby="accordeonPost" data-bs-parent="#accordionPost">
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
            postDescription: ''
        }
    },
    components: {
        editor: Editor
    },
    methods: {
        async mounted() {
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
            const result = await fetch(this.postType + '/Publish', requestOptions);
            await this.refresh();
        },
        async delete(id) {
            await fetch(this.postType + '/Delete?id=' + id, { method: "DELETE" });
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