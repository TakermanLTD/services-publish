<template>
  <section class="container">
    <div class="form-group">
      <label for="itemName">Name</label>
      <input type="text" name="itemName" id="itemName" class="form-control" placeholder="Name" aria-describedby="itemName">
      <small id="itemName" class="text-muted">Put the item name here</small>
    </div>
    <br />
    <div class="form-group">
      <label for="itemDescription">Description</label>
      <textarea name="itemDescription" id="itemDescription" class="form-control" placeholder="Description" aria-describedby="itemDescription"></textarea>
      <small id="itemDescription" class="text-muted">Put the description here</small>
    </div>
    <br />
    <div class="form-group">
      <label for="marketplaces">Marketplaces</label>
      <br />
      <div class="form-check form-check-inline">
        <label class="form-check-label">
          <input class="form-check-input" type="checkbox" name="cbxAmazon" id="cbxAmazon" value="Amazon"> Amazon
        </label>
      </div>
      <br />
      <div class="form-check form-check-inline">
        <label class="form-check-label">
          <input class="form-check-input" type="checkbox" name="cbxOlx" id="cbxOlx" value="OLX"> OLX
        </label>
      </div>
      <br />
      <div class="form-check form-check-inline">
        <label class="form-check-label">
          <input class="form-check-input" type="checkbox" name="cbxBazar" id="cbxBazar" value="Bazar"> Bazar
        </label>
      </div>
      <br />
      <div class="form-check form-check-inline">
        <label class="form-check-label">
          <input class="form-check-input" type="checkbox" name="cbxEbay" id="cbxEbay" value="Ebay"> Ebay
        </label>
      </div>
      <br />
      <small id="marketplaces" class="text-muted">Check the desired marketplaces</small>
    </div>
    <br />
    <div class="custom-file mt-3 mb-3">
      <input type="file" class="custom-file-input" id="pictures" style="border: 1px solid black;"> <br />
      <label class="custom-file-label" for="pictures">Upload pictures</label>
    </div>
    <button type="submit" class="btn btn-primary">Publish</button>
  </section>
</template>

<script lang="js">
export default {
  data() {
    return {
    }
  }
}
</script>

<style scoped></style>
