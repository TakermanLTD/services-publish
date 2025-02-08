<template>
    <div class="row">
        <div class="table-responsive">
            <table class="table table">
                <thead>
                    <tr class="table-primary">
                        <th></th>
                        <th>
                            <label for="platform" class="form-label">Platform</label>
                            <input type="text" class="form-control" id="platform" placeholder="Platform" v-model="this.platformName" />
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
                    <tr v-for="(platform, index) in this.platforms" :key="index">
                        <td scope="row">{{ platform.id }}</td>
                        <td>{{ platform.name }}</td>
                        <td>
                            <button @click="this.delete(platform.id)" type="button" class="btn btn-danger">
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
            platforms: [],
            platformName: ''
        }
    },
    async mounted() {
        await this.refresh();
    },
    methods: {
        async refresh() {
            this.platforms = await (await fetch('/Platforms/GetAll')).json();
        },
        async add() {
            let newPlatform = await (await fetch('/Platforms/Create', {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ name: this.platformName })
            })).json();
            this.platformName = '';
            await this.refresh();
        },
        async delete(id) {
            if (confirm('Do you want to delete it for sure?')) {
                let removed = await (await fetch('/Platforms/Delete?id=' + id, {
                    method: "DELETE"
                })).json();
                await this.refresh();
            }
        }
    },
}
</script>