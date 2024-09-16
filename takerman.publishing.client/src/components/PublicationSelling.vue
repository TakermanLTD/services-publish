<template>
    <div class="accordion" id="accordionSelling">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonSelling">
                <button class="accordion-button text-center collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSelling" aria-expanded="false" aria-controls="collapseSelling">
                    Publications
                </button>
            </h2>
            <div id="collapseSelling" class="accordion-collapse collapse" aria-labelledby="accordeonSelling" data-bs-parent="#accordionSelling">
                <div class="accordion-body">
                    <table class="table table-responsive">
                        <tbody>
                            <tr>
                                <th>ID</th>
                                <th>Name</th>
                                <th>Description</th>
                                <th>Price</th>
                                <th>Pictures</th>
                                <th>Videos</th>
                                <th></th>
                            </tr>
                            <tr v-for="(publication, index) in this.publications" :key="index">
                                <td>{{ publication.id }}</td>
                                <td>{{ publication.postName }}</td>
                                <td>{{ publication.postDescription }}</td>
                                <td>{{ publication.postPrice }}</td>
                                <td>{{ publication.postPictures }}</td>
                                <td>{{ publication.postVideos }}</td>
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
            <h2 class="accordion-header" id="accordeonSelling">
                <button class="accordion-button text-center" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSelling" aria-expanded="true" aria-controls="collapseSelling">
                    Post
                </button>
            </h2>
            <div id="collapseSelling" class="accordion-collapse collapse show" aria-labelledby="accordeonSelling" data-bs-parent="#accordionSelling">
                <div class="accordion-body">
                    <div class="form-group">
                        <label for="postName">Name</label>
                        <input type="text" id="postName" class="form-control" placeholder="Name" aria-describedby="postName" v-model="postName" />
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="postDescription">Description</label>
                        <editor api-key="u43iacolfm6l254nstw823zqhc7402lhndz1s3fd9tac7u51" id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></editor>
                    </div>
                    <br />
                    <div class="form-group">
                        <label for="postPrice">Price</label>
                        <input id="postPrice" class="form-control" placeholder="Price" aria-describedby="postPrice" v-model="postPrice"></input>
                    </div>
                    <br />
                    <div class="custom-file mt-3 mb-3">
                        <input type="file" class="custom-file-input form-control" id="pictures" style="border: 1px solid black" />
                    </div>
                    <br />
                    <div class="custom-file mt-3 mb-3">
                        <input type="file" class="custom-file-input form-control" id="videos" style="border: 1px solid black" />
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
            postPrice: 0,
            postPictures: [],
            postVideos: [],
            publications: []
        }
    },
    components: {
        editor: Editor
    },
    methods: {
        async refresh() {
            this.publications = await (await fetch('Selling/GetAll?project=' + this.project)).json();
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
                PostPrice: this.postPrice,
                PostPictures: this.postPictures,
                PostVideos: this.postVideos
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Selling/Publish', requestOptions);
            await this.refresh();
        },
        async delete(id) {
            await fetch('Selling/Delete?id=' + id, { method: "DELETE" });
            await this.refresh();
        },
        async fill(id) {
            let publication = await fetch('Selling/Get?id=' + id);
            this.postName = publication.postName;
            this.postDescription = publication.postDescription;
            this.postPrice = publication.postPrice;
            this.postPictures = publication.postPictures;
            this.postVideos = publication.postVideos;
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