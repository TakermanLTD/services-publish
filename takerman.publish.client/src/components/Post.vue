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
                        <label for="title">Title</label>
                        <input type="text" id="title" class="form-control" placeholder="Title" aria-describedby="title" v-model="title" />
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="content">Content</label>
                        <tinymce api-key="u43iacolfm6l254nstw823zqhc7402lhndz1s3fd9tac7u51" id="content" class="form-control" 
                        placeholder="Content" aria-describedby="content" v-model="content"
                        :init="{
                            selector: 'textarea',  // change this value according to your HTML
                            skin: 'oxide-dark',
                            content_css: 'dark'
                        }" />
                    </div>
                    <div class="form-group">
                        <div v-if="postId">
                            <button @click="update" class="btn btn-success text-center">Update</button>
                        </div>
                        <div v-else>
                            <button @click="create" class="btn btn-info text-center">Create</button>
                            <button @click="publish" class="btn btn-success text-center">Publish</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script lang="js">
import tinymce from '@tinymce/tinymce-vue';
export default {
    data() {
        return {
            title: '',
            content: '',
            price: 0,
            userId: 0
        }
    },
    components: {
        tinymce
    },
    async mounted() {
        this.userId = this.$auth0.user.sub;
    },
    methods: {
        async create() {
            const data = JSON.stringify({
                userId: this.userId,
                project: {},
                projectId: this.project,
                postType: {},
                postTypeId: this.postType,
                title: this.title,
                content: this.content,
                price: this.price
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Posts/Create', requestOptions);
            
            if (result.ok) {
                alert('Post created:', result.statusText);
                this.title = '';
                this.content = '';
                this.price = 0;
                await this.fetchPosts();
            } else {
                console.error('Failed to create post:', result.statusText);
            }
        },
        async update() {
            const data = JSON.stringify({
                userId: this.userId,
                project: {},
                projectId: this.project,
                postType: {},
                postTypeId: this.postType,
                title: this.title,
                content: this.content,
                price: this.price
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('/Posts/Update', requestOptions);
        },
        async publish() {
            let platforms = [];
            let platfromsDom = document.querySelectorAll('.platform:checked');
            for (let i = 0; i < platfromsDom.length; i++) {
                platforms.push(Number(platfromsDom[i].value));
            }
            const data = JSON.stringify({
                userId: this.userId,
                project: {},
                projectId: this.project,
                postType: {},
                postTypeId: this.postType,
                title: this.title,
                content: this.content,
                price: this.price
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('/Posts/Publish', requestOptions);
        },
        async delete(id) {
            await fetch('/Posts/Delete?id=' + id, { method: "DELETE" });
        }
    },
    watch: {
        async project(newProject) {
        },
        async postType(newPostType) {
        }
    },
    props: {
        postId: Number,
        project: Number,
        postType: Number
    }
}
</script>