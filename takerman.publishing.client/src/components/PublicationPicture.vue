<template>
    <div class="publication">
        <div class="form-group">
            <label for="postDescription">Description</label>
            <textarea id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></textarea>
        </div>
        <br />
        <div class="custom-file mt-3 mb-3">
            <input type="file" class="custom-file-input" id="pictures" style="border: 1px solid black" />
        </div>
        <div class="form-group">
            <button @click="publish" class="btn btn-success text-center">Publish</button>
        </div>
    </div>
    <div class="publications">
        <h3 class="text-center">Publications</h3>
        <table class="table table-responsive">
            <tr>
                <th>ID</th>
                <th>Description</th>
                <th>Pictures</th>
                <th></th>
            </tr>
            <tr v-for="(publication, index) in this.publications" :key="index">
                <td>{{ publication.id }}</td>
                <td>{{ publication.postDescription }}</td>
                <td>{{ publication.postPictures }}</td>
                <td>
                    <button @click="this.delete(publication.id)" class="btn btn-danger"><i class="bi bi-x-circle-fill"></i></button>
                    <button @click="this.fill(publication.id)" class="btn btn-info"><i class="bi bi-arrow-up-square-fill"></i></button>
                </td>
            </tr>
        </table>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            postDescription: '',
            postPictures: [],
            publications: []
        }
    },
    methods: {
        async refresh() {
            this.publications = await (await fetch('Pictures/GetAll?project=' + this.project)).json();
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
                PostPictures: this.postPictures
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Pictures/Publish', requestOptions);
            await this.refresh();
        },
        async delete(id) {
            await fetch('Pictures/Delete?id=' + id, { method: "DELETE" });
            await this.refresh();
        },
        async fill(id) {
            let publication = await fetch('Pictures/Get?id=' + id);
            this.postDescription = publication.postDescription;
            this.postPictures = publication.postPictures;
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