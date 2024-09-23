<template>
    <div class="row">
    </div>
    <div class="row">
        <div class="table-responsive">
            <table class="table table">
                <thead>
                    <tr class="table-primary">
                        <th></th>
                        <th>
                            <label for="postType" class="form-label">Post Type</label>
                            <input type="text" class="form-control" id="postType" placeholder="PostType" v-model="this.postTypeName" />
                        </th>
                        <th>
                            <button @click="add" type="button" class="btn btn-success">
                                <i class="fa-solid fa-plus"></i>
                            </button>
                        </th>
                    </tr>
                    <tr class="table-primary">
                        <th scope="col">Id</th>
                        <th scope="col">Name</th>
                        <th>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(postType, index) in this.postTypes" :key="index">
                        <td scope="row">{{ postType.id }}</td>
                        <td>{{ postType.name }}</td>
                        <td>
                            <button @click="this.delete(postType.id)" type="button" class="btn btn-danger">
                                <i class="fa-solid fa-minus"></i>
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            postTypes: [],
            postTypeName: ''
        }
    },
    async mounted() {
        await this.refresh();
    },
    methods: {
        async refresh() {
            this.postTypes = await (await fetch('/PostTypes/GetAll')).json();
        },
        async add() {
            let newPostType = await (await fetch('/PostTypes/Create', {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ name: this.postTypeName })
            })).json();
            this.postTypeName = '';
            await this.refresh();
        },
        async delete(id) {
            if (confirm('Do you want to delete it for sure?')) {
                let removed = await (await fetch('/PostTypes/Delete?id=' + id, {
                    method: "DELETE"
                })).json();
                await this.refresh();
            }
        }
    },
}
</script>