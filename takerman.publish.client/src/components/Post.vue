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
                        <label for="thumbnail">Thumbnail</label>
                        <input
                               type="file"
                               id="thumbnail"
                               class="form-control"
                               @change="async ($event) => {
                                if ($event.target.files?.[0]) {
                                    thumbnail = await convertImageToByteArray($event.target.files[0]);
                                }
                            }"
                               accept="image/*" />

                        <img v-if="thumbnail"
                             :src="thumbnailPreview"
                             class="img-fluid thumbnail-preview rounded"
                             alt="Thumbnail preview">
                    </div>
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
                    <div v-if="isLoading" class="d-flex justify-content-center my-3">
                        <div class="spinner-border text-primary" role="status">
                            <span class="visually-hidden">Loading...</span>
                        </div>
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
    import { Buffer } from 'buffer';
    export default {
        data() {
            return {
                title: '',
                content: '',
                price: 0,
                userId: 0,
                thumbnail: null,
                isLoading: false
            }
        },
        components: {
            tinymce
        },
        computed: {
            thumbnailPreview() {
                if (!this.thumbnail) return '';
                const uint8Array = new Uint8Array(this.thumbnail);
                return `data:image/jpeg;base64,${Buffer.from(uint8Array).toString('base64')}`;
            }
        },
        async mounted() {
            this.userId = this.$auth0.user.sub;
        },
        methods: {

            async convertImageToByteArray(file) {
                return new Promise((resolve, reject) => {
                    const reader = new FileReader();
                    reader.onloadend = () => {
                        const byteArray = new Uint8Array(reader.result);
                        resolve(Array.from(byteArray));
                    };
                    reader.onerror = reject;
                    reader.readAsArrayBuffer(file);
                });
            },
            async getPost(id) {
                const result = await fetch(`/Posts/Get?id=${id}`);
                if (result.ok) {
                    const post = await result.json();
                    this.title = post.title;
                    this.content = post.content;
                    this.price = post.price;
                    this.thumbnail = post.thumbnail;
                }
            },
            async create() {
                this.isLoading = true;
                try {
                    const thumbnailBase64 = this.thumbnail ? Buffer.from(this.thumbnail).toString('base64') : null;
                    const data = JSON.stringify({
                        userId: this.userId,
                        project: {},
                        projectId: this.project,
                        postType: {},
                        postTypeId: this.postType,
                        title: this.title,
                        content: this.content,
                        price: this.price,
                        thumbnail: thumbnailBase64
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
                        this.thumbnail = null;
                    } else {
                        console.error('Failed to create post:', result.statusText);
                    }
                } finally {
                    this.isLoading = false;
                }
            },
            async update() {
                this.isLoading = true;
                try {
                    const data = JSON.stringify({
                        userId: this.userId,
                        project: {},
                        projectId: this.project,
                        postType: {},
                        postTypeId: this.postType,
                        title: this.title,
                        content: this.content,
                        price: this.price,
                        thumbnail: this.thumbnail
                    });
                    const requestOptions = {
                        method: "POST",
                        headers: { "Content-Type": "application/json" },
                        body: data
                    };
                    const result = await fetch('/Posts/Update', requestOptions);
                    if (result.ok) {
                        alert('Post updated:', result.statusText);
                    } else {
                        console.error('Failed to update post:', result.statusText);
                    }
                } finally {
                    this.isLoading = false;
                }
            },
            async publish() {
                this.isLoading = true;
                try {
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
                        price: this.price,
                        platforms: platforms
                    });
                    const requestOptions = {
                        method: "POST",
                        headers: { "Content-Type": "application/json" },
                        body: data
                    };
                    const result = await fetch('/Posts/Publish', requestOptions);
                    if (result.ok) {
                        alert('Post published:', result.statusText);
                    } else {
                        console.error('Failed to publish post:', result.statusText);
                    }
                } finally {
                    this.isLoading = false;
                }
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
<style scoped>
    .thumbnail-preview {
        max-width: 200px;
        margin: 10px 0;
    }
</style>