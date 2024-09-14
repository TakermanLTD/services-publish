<template>
    <div class="accordion" id="accordionVideo">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonVideo">
                <button class="accordion-button text-center collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseVideo" aria-expanded="false" aria-controls="collapseVideo">
                    Publications
                </button>
            </h2>
            <div id="collapseVideo" class="accordion-collapse collapse" aria-labelledby="accordeonVideo" data-bs-parent="#accordionVideo">
                <div class="accordion-body">
                    <table class="table table-responsive">
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Video</th>
                            <th></th>
                        </tr>
                        <tr v-for="(publication, index) in this.publications" :key="index">
                            <td>{{ publication.id }}</td>
                            <td>{{ publication.postName }}</td>
                            <td>{{ publication.postDescription }}</td>
                            <td>{{ publication.postVideo }}</td>
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
            <h2 class="accordion-header" id="accordeonVideo">
                <button class="accordion-button text-center" type="button" data-bs-toggle="collapse" data-bs-target="#collapseVideo" aria-expanded="true" aria-controls="collapseVideo">
                    Post
                </button>
            </h2>
            <div id="collapseVideo" class="accordion-collapse collapse show" aria-labelledby="accordeonVideo" data-bs-parent="#accordionVideo">
                <div class="accordion-body">
                    <div class="form-group">
                        <label for="postName">Name</label>
                        <input type="text" id="postName" class="form-control" placeholder="Name" aria-describedby="postName" v-model="postName" />
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="postDescription">Description</label>
                        <textarea id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></textarea>
                    </div>
                    <br />
                    <div class="custom-file mt-3 mb-3">
                        <input type="file" class="custom-file-input form-control" id="video" style="border: 1px solid black" />
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
export default {
    data() {
        return {
            postName: '',
            postDescription: '',
            postVideo: [],
            publications: []
        }
    },
    methods: {
        async refresh() {
            this.publications = await (await fetch('Video/GetAll?project=' + this.project)).json();
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
                PostName: this.postName,
                PostDescription: this.postDescription,
                PostVideo: this.postVideo
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Video/Publish', requestOptions);
            await this.refresh();
        },
        async delete(id) {
            await fetch('Video/Delete?id=' + id, { method: "DELETE" });
            await this.refresh();
        },
        async fill(id) {
            let publication = await fetch('Video/Get?id=' + id);
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