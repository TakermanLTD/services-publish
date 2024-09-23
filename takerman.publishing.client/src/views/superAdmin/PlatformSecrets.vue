<template>
    <div class="row">
    </div>
    <div class="row">
        <div class="table-responsive">
            <table class="table table">
                <thead>
                    <tr class="table-primary">
                        <th></th>
                        <th colspan="3">
                            <label class="form-label text-center" for="ddlPlatform">Platform</label>
                            <select @change="this.refresh()" v-model="selectedPlatform" class="form-select" id="ddlPlatform">
                                <option v-for="(platform, index) in platforms" :key="index" :value="platform.id">{{ platform.name }}</option>
                            </select>
                        </th>
                    </tr>
                    <tr class="table-primary">
                        <th scope="col"></th>
                        <th>
                            <label for="platformLinkName" class="form-label">Name</label>
                            <input type="text" class="form-control" id="platformLinkName" placeholder="Name" v-model="this.newPlatformLinkName" />
                        </th>
                        <th>
                            <button @click="add" type="button" class="btn btn-success">
                                <i class="fa-solid fa-plus"></i>
                            </button>
                        </th>
                    </tr>
                    <tr class="table-primary">
                        <th scope="col">Id</th>
                        <th>Name</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(platformSecret, index) in this.platformSecrets" :key="index">
                        <td scope="row">{{ platformSecret.id }}</td>
                        <td>{{ platformSecret.name }}</td>
                        <td>
                            <button @click="this.delete(platformSecret.id)" type="button" class="btn btn-danger">
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
            platformSecrets: [],
            selectedPlatform: 0,
            newPlatformLinkName: ''
        }
    },
    async mounted() {
        this.platforms = await (await fetch('/Platforms/GetAll')).json();
        if (this.platforms && this.platforms.length > 0) {
            this.selectedPlatform = this.platforms[0].id;
        }
        this.refresh();
    },
    methods: {
        async refresh() {
            this.platformSecrets = await (await fetch('/PlatformSecrets/GetAll?platformId=' + this.selectedPlatform)).json();
        },
        async add() {
            let newPlatformSecrets = await (await fetch('/PlatformSecrets/Create', {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    name: this.newPlatformLinkName,
                    platformId: this.selectedPlatform,
                    platform: {}
                })
            })).json();
            this.newPlatformLinkName = '';
            await this.refresh();
        },
        async delete(id) {
            if (confirm('Do you want to delete it for sure?')) {
                let removed = await (await fetch('/PlatformSecrets/Delete?id=' + id, {
                    method: "DELETE"
                })).json();
                await this.refresh();
            }
        }
    }
}
</script>