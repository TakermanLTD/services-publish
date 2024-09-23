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
                            <label for="platformLinkUrl" class="form-label">URL</label>
                            <input type="text" class="form-control" id="platformLinkUrl" placeholder="Url" v-model="this.newPlatformLinkUrl" />
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
                        <th>URL</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(platformLinks, index) in this.platformLinks" :key="index">
                        <td scope="row">{{ platformLinks.id }}</td>
                        <td>{{ platformLinks.name }}</td>
                        <td>{{ platformLinks.url }}</td>
                        <td>
                            <button @click="this.delete(platformLinks.id)" type="button" class="btn btn-danger">
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
            platformLinks: [],
            selectedPlatform: 0,
            newPlatformLinkName: '',
            newPlatformLinkUrl: ''
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
            this.platformLinks = await (await fetch('/PlatformLinks/GetAll?platformId=' + this.selectedPlatform)).json();
        },
        async add() {
            let newPlatformLinks = await (await fetch('/PlatformLinks/Create', {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    name: this.newPlatformLinkName,
                    url: this.newPlatformLinkUrl,
                    platformId: this.selectedPlatform,
                    platform: {}
                })
            })).json();
            this.newPlatformLinkName = '';
            this.newPlatformLinkUrl = '';
            await this.refresh();
        },
        async delete(id) {
            if (confirm('Do you want to delete it for sure?')) {
                let removed = await (await fetch('/PlatformLinks/Delete?id=' + id, {
                    method: "DELETE"
                })).json();
                await this.refresh();
            }
        }
    }
}
</script>