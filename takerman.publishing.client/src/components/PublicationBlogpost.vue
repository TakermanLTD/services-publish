<template>
    <div class="publication">
        <div class="form-group">
            <label for="postName">Name</label>
            <input type="text" id="postName" class="form-control" placeholder="Name" aria-describedby="postName" v-model="postName" />
        </div>
        <br />
        <div class="form-group">
            <label for="postDescription">Content</label>
            <textarea id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></textarea>
        </div>
        <div class="form-group">
            <button @click="publish" class="btn btn-success text-center">Publish</button>
        </div>
    </div>
    <div class="publications">
        <h3 class="text-center">Publications</h3>
        <table class="table table-striped table-responsive text-center">
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
</template>
<script lang="js">
export default {
    data() {
        return {
            postName: '',
            postDescription: '',
            publications: []
        }
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